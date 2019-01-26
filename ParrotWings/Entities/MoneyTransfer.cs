using System;
using System.Collections.Generic;
using System.Text;

namespace ParrotWings.Entities
{
    /// <summary>
    /// Денежный перевод на сайте ПМ
    /// </summary>
    public class MoneyTransfer
    {
        /// <summary>
        /// ID транзакции денежного перевода
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Сумма денежного перевода
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// ID отправителя
        /// </summary>
        public long SenderId { get; set; }

        /// <summary>
        /// ID получателя
        /// </summary>
        public long RecipientId { get; set; }

        /// <summary>
        /// Дата и время создания транзакции
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата подтверждения транзакции
        /// </summary>
        public DateTime? CommitAt { get; set; }
    }
}