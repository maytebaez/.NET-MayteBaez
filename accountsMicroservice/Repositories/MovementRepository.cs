using System.Diagnostics;
using AccountsMicroservice.Data;
using AccountsMicroservice.Exceptions;
using AccountsMicroservice.Models;

namespace AccountsMicroservice.Repositories
{
    public class MovementRepository : Repository<Movement>
    {
        public MovementRepository(AppDbContext context) : base(context) { }

        public override async Task AddAsync(Movement movement)
        {
            var account = GetAccount(movement.AccountNumber);

            ValidateHasAvailableBalance(account.Balance, movement.Ammount);
            SetValues(movement, account);

            await base.AddAsync(movement);
            await UpdateBalance(account, movement.Ammount);
        }

        public async Task<object> GetMovementsByDateAndClient(int clientId, DateTime initialDate, DateTime endDate){
            var movements = from movement in _context.Movimientos
                            join account in _context.Cuentas
                            on movement.AccountNumber equals account.Number
                            where account.ClientId == clientId &&
                            movement.Date.Date >= initialDate &&
                            movement.Date.Date <= endDate
                            group new {movement, account} by movement.AccountNumber into newGroup
                            select new
                            {
                                NumeroDeCuenta = newGroup.Key,
                                TipoDeCuenta = newGroup.Select(c => c.account.Type).First(),
                                Movimientos = newGroup.Select(g => new{
                                    Fecha = g.movement.Date,
                                    Tipo = g.movement.Type,
                                    Monto = g.movement.Ammount
                                }).ToList()
                            };

            return movements;
        }

        private Account GetAccount(string accountNumber){
            return _context.Cuentas.FirstOrDefault( a => a.Number == accountNumber) ??
                    throw new ValidationException("No existe la cuenta ingresada.");
        }

        private void SetValues(Movement movement, Account account){
            movement.AccountNumber = account.Number;
            movement.Account = account;
            movement.InitialBalance = account.Balance;
            movement.Type = movement.Ammount > 0 ? "Deposito" : "Retiro";
            movement.Date = DateTime.Now;
        }

        private async Task UpdateBalance(Account account, float ammount){
            account.Balance += ammount;
            await _context.SaveChangesAsync();
        }

        private void ValidateHasAvailableBalance(float accountBalance, float movementAmmount)
        {
            if(movementAmmount < 0 && accountBalance < Math.Abs(movementAmmount)){
                throw new ValidationException("Saldo no disponible");
            }
        }
    }
}