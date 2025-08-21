namespace MaxNet.Utility
{
    /// <summary>
    /// Утилитарный класс для валидации параметров с выбрасыванием исключений при ошибках
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Проверяет, что объект не равен <c>null</c>. 
        /// В случае <c>null</c> выбрасывает <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <param name="paramName"> Имя параметра </param>
        /// <param name="data"> Объект для проверки </param>
        public static void NotNull(string paramName, object? data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(paramName, $"Parameter '{paramName}' is null!");
            }
        }

        /// <summary>
        /// Проверяет, что строка не равна <c>null</c> и не пуста. 
        /// В противном случае выбрасывает <see cref="ArgumentNullException"/>.
        /// </summary>
        /// <param name="paramName"> Имя параметра </param>
        /// <param name="text"> Строка для проверки </param>
        public static void NotNullOrEmpty(string paramName, string? text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(paramName, $"Parameter '{paramName}' is null or empty!");
            }
        }
    }
}