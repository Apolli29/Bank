using System;

namespace BankAccountNS
{
    /// <summary>
    /// Класс, представляющий банковский счет клиента.
    /// Позволяет выполнять операции списания и пополнения средств.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Имя владельца света
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Списания меньше нуля.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private readonly string m_customerName;
        /// <summary>
        /// Текущий баланс счета
        /// </summary>
        private double m_balance;
        /// <summary>
        /// Закрытый конструктор по умолчанию
        /// </summary>
        private BankAccount() { }

        /// <summary>
        /// Создает новый банковский счет
        /// </summary>
        /// <param name="customerName">Имя клиента</param>
        /// <param name="balance">Начальный баланс счета</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Получает имя владельца счета
        /// </summary>
        /// <value>Имя клиента</value>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Получает текущий баланс счета
        /// </summary>
        /// <value>Текущи баланс</value>

        public double Balance
        {
            get { return m_balance; }
        }
        /// <summary>
        /// Метод снятия средств со счета
        /// </summary>
        /// <param name="amount">Сумма списания</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если сумма больше баланса или меньше нуля
        /// </exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }

        /// <summary>
        /// Метод зачисления средств на счет
        /// </summary>
        /// <param name="amount">Сумма зачисления</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если сумма меньше нуля
        /// </exception>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }
        /// <summary>
        /// Точка входа в программу
        /// </summary>

        static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);

            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}