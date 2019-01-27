using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ParrotWings.Contexts;
using ParrotWings.Interfaces;

namespace ParrotWings.Entities
{
    public class MoneyTransferHistory
    {
        #region Properties

        /// <summary>
        /// Дата завершения транзации
        /// </summary>
        public DateTime CommitAt { get; set; }

        /// <summary>
        /// Полное имя корреспондента
        /// </summary>
        public string CorrespondentName { get; set; }

        /// <summary>
        /// Сумма, задействованная в транзакции
        /// </summary>
        public long TransactionAmount { get; set; }

        /// <summary>
        /// Баланс после транзакции
        /// </summary>
        public long ResultingBalance { get; set; }


        #endregion

        public static List<MoneyTransferHistory> GetMoneyTransferHistoryByEmail(IDbRepository dbRepository,
            string email)
        {
            var sqlQuery = @";WITH fullName AS
                (
	                SELECT Name + ' ' + SurName AS fn 
	                FROM AspNetUsers WHERE Email = @email
                )
            SELECT 
	            CommitAt,
	            (SELECT fn FROM fullName) AS CorrespondentName,
	            IIF(@email = RecipientEmail, -1, 1) * amount AS TransactionAmount,
	            500 + sum(Amount) OVER (ORDER BY commitAt) AS ResultingBalance
            FROM MoneyTransfers AS mt
            WHERE @email IN (SenderEmail, RecipientEmail) AND CommitAt IS NOT NULL
            ORDER BY CommitAt;";

            var param = new SqlParameter("@email", email);

            var moneyTransferHistory = dbRepository.ExecuteQuery<MoneyTransferHistory>(sqlQuery, param).ToList();

            return moneyTransferHistory;
        }
    }
}