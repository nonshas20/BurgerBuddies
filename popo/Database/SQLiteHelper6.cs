using popo.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popo.Database
{
    public class SQLiteHelper6
    {
        private readonly SQLiteAsyncConnection db; // Initializing the database

        public SQLiteHelper6(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<RecieptModel>(); // Create table based on Login Model
        }
        /*public async Task<int> CreateReciept()
        {
            var transactions = await db.Table<TransactionModel>().ToListAsync();

            // Get all orders from the database
            var orders = await db.Table<OrderModel>().ToListAsync();

            // Perform an inner join on transaction_id
            var joinedTransactions =
                from transaction in transactions
                join order in orders on transaction.Transaction_Id equals order.Transaction_Id
                select new RecieptModel
                {
                    Transaction_Id = transaction.Transaction_Id,
                    Order_Id = order.Order_Id,
                    Product_Name = order.Product_Name,
                    Product_Cost = order.Product_Cost,
                    Order_Qty = order.Order_Qty,
                    Order_Amt = order.Order_Amt
                };
            await db.InsertAsync(joinedTransactions.ToList());
        }*/

        public async Task InsertRecieptModels(List<RecieptModel> recieptModels)
        {
            foreach (var recieptModel in recieptModels)
            {
                await db.InsertAsync(recieptModel);
            }
        }


        public async Task<List<RecieptModel>> ViewCart2(OrderModel orderedItem)
        {
            // Perform the join operation without inserting into the database.
            var transactions = await db.Table<TransactionModel>().ToListAsync();
            var orders = await db.Table<OrderModel>().ToListAsync();

            var joinedTransactions =
                from transaction in transactions
                join order in orders on transaction.Transaction_Id equals order.Transaction_Id
                select new RecieptModel
                {
                    Transaction_Id = transaction.Transaction_Id,
                    Order_Id = order.Order_Id,
                    Product_Name = order.Product_Name,
                    Product_Cost = order.Product_Cost,
                    Order_Qty = order.Order_Qty,
                    Order_Amt = order.Order_Amt
                };

            // Insert each RecieptModel object into the database
            await InsertRecieptModels(joinedTransactions.ToList());

            // Return the list of RecieptModel objects
            return joinedTransactions.ToList();
        }



    }
}
