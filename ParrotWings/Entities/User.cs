namespace ParrotWings.Entities
{
    /// <summary>
    /// Пользователь сайта PW
    /// </summary>
    public class User
    {
        #region Properties

        /// <summary>
        /// ID пользователя
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя от учетной записи
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Текщийй баланс пользователя
        /// </summary>
        public decimal Balance { get; set; }

        #endregion
    }
}