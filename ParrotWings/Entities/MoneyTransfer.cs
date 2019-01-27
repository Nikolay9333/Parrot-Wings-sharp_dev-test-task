using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Сумма денежного перевода
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// почта отправителя (FK)
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// Отправитель
        /// </summary>
        [ForeignKey("SenderEmail")]
        public User Sender { get; set; }

        /// <summary>
        /// Почта получателя (FK)
        /// </summary>
        public string RecipientEmail { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        [ForeignKey("RecipientEmail")]
        public User Recipient { get; set; }

        /// <summary>
        /// Дата и время создания транзакции
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Дата подтверждения транзакции
        /// </summary>
        public DateTime? CommitAt { get; set; }
    }
}