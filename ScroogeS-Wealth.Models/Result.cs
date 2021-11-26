using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Models
{
    public class Result<T>
    {
        public string Message { get; set; }

        /// <summary>
        /// Это свойство принимает значение 0 или один. То есть если операция прошла успешно, статус будет 1, иначе 0.
        /// </summary>
        public Status Status { get; set; }

        public T Body { get; set; }

        public Result(int status, string message)
        {
            Message = message;
            Status = (Status)status;
        }

        public Result(int status, T body, string message)
        {
            Body = body;
            Message = message;
            Status = (Status)status;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Result<T> m = obj as Result<T>;
            if (m as Result<T> == null)
                return false;
            bool temp=true;
            if (Body!=null)
            { temp = Body.Equals(m.Body); }            
            return m.Status == Status && m.Message == Message && temp;
        }

        public override int GetHashCode()
        {
            int unitCode=0;
            switch (Message)
            {
                case "создано":
                    unitCode = 1;
                    break;
                case "сущность не найдена":
                     unitCode = 2;
                    break;
                case "название изменено":
                     unitCode = 3;
                    break;
                case "баланс изменен":
                    unitCode = 4;
                    break;
            }           
            return (int)Status + unitCode;
        }
    }
}
