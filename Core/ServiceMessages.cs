using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ServiceMessages
    {
        public const string entityNotFound = "Сущность не найдена";
        public const string Created = "Создано";
        public const string nameChanged = "Название изменено";
        public const string categoryChanged = "Категория изменена";
        public const string summChanged = "Сумма изменена";
        public const string balanceChanged = "Баланс изменен";
        public const string deletionCompleted = "Удалено";
        public const string expenseAdded = "Расход добавлен";
        public const string incomeAdded = "Доход добавлен";

        public const string takeIntoAccountNextMonth = "Будет учтен в следующем месяце";
    }
}
