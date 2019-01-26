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
        /// ID отправителя
        /// </summary>
        public long SenderId { get; set; }

        /// <summary>
        /// Отправитель
        /// </summary>
        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        /// <summary>
        /// ID получателя
        /// </summary>
        public long RecipientId { get; set; }

        /// <summary>
        /// Получатель
        /// </summary>
        [ForeignKey("RecipientId")]
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