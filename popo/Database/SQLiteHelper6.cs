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
        /*public List<RecieptModel> SortRecieptModelsByTransactionId(List<RecieptModel> joinedTransactions, int transactionId)
        {
            // Filter the joined transactions by the given transactionId
            var filteredTransactions = joinedTransactions.Where(t => t.Transaction_Id == transactionId).ToList();

            // Sort the filtered transactions by Order_Id (optional, you can change the sorting criteria if needed)
            filteredTransactions.Sort((t1, t2) => t1.Order_Id.CompareTo(t2.Order_Id));

            return filteredTransactions;
        }*/

        public async Task<List<RecieptModel>> ViewCart2(OrderModel orderedItem, int transactionId)
        {
            // Perform the join operation without inserting into the database.
            var orders = await App.OrderedItemsDatabase.ReadOrders();
            var transactions = await App.TransactionDatabase.ReadTransactions();

            List<OrderItem> orderItems = new List<OrderItem>();
            List<TransactionItem> transactionItems = new List<TransactionItem>();

            foreach (var order in orders)
            {
                OrderItem orderItem = new OrderItem
                {
                    Order_Id = order.Order_Id,
                    Transaction_Id = order.Transaction_Id,
                    Product_Name = order.Product_Name,
                    Product_Cost = order.Product_Cost,
                    Order_Qty = order.Order_Qty,
                    Order_Amt = order.Order_Amt
                };
                orderItems.Add(orderItem);
            }

            foreach (var transaction in transactions)
            {
                TransactionItem transactItem = new TransactionItem
                {
                    Transaction_Id = transaction.Transaction_Id,
                    Payment_Mode = transaction.Payment_Mode,
                    Order_Mode = transaction.Order_Mode,
                    Order_Status = transaction.Order_Status,
                    Date = transaction.Date,
                    Order_Total = transaction.Order_Total
                };
                transactionItems.Add(transactItem);
            }

            var joinedTransactions =
                from transaction in transactionItems
                join order in orderItems on transaction.Transaction_Id equals order.Transaction_Id
                select new RecieptModel
                {
                    Transaction_Id = transaction.Transaction_Id,
                    Order_Id = order.Order_Id,
                    Product_Name = order.Product_Name,
                    Product_Cost = order.Product_Cost,
                    Order_Qty = order.Order_Qty,
                    Order_Amt = order.Order_Amt
                };
            
             // Filter the joined transactions by the given transactionId
            var filteredTransactions = joinedTransactions.Where(t => t.Transaction_Id == transactionId).ToList();

            // Sort the filtered transactions by Order_Id (optional, you can change the sorting criteria if needed)
            filteredTransactions.Sort((t1, t2) => t1.Order_Id.CompareTo(t2.Order_Id));
            
            //Insert each RecieptModel object into the database
            await InsertRecieptModels(filteredTransactions.ToList());
            //Return the list of RecieptModel objects
            return filteredTransactions.ToList();
             
            /*
            //Insert each RecieptModel object into the database
            await InsertRecieptModels(joinedTransactions.ToList());
            //Return the list of RecieptModel objects
            return joinedTransactions.ToList();
            */
            
        }
    }
}
