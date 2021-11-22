using Core;
using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class WorkSpaceLogic<T> where T : IBaseModel
    {
        GenericStorage<WorkSpace> workSpaceStore = new GenericStorage<WorkSpace>();
        GenericStorage<User> userStore = new GenericStorage<User>();
        public Result<WorkSpace> Get(int userId)
        {
           var workSpace = workSpaceStore.Get().FirstOrDefault(x => x.GeneralUser.Id == userId);
            if(workSpace is null)
            {
                return new Result<WorkSpace>(0, "Рабочее пространство не найдено");
            }
            return new Result<WorkSpace>(1, workSpace, "Ок");
        }

        public Result<WorkSpace> Create(int userId)
        {
            var user = userStore.Get().FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                return new Result<WorkSpace>(0, "юзен не найден");

            }
            WorkSpace workSpace = new WorkSpace(user);
            var workSpaces = workSpaceStore.Get();
            int id = CreateId(workSpaces);
            workSpace.Id = id;
            workSpaceStore.Add(workSpace);
            return new Result<WorkSpace>(1, workSpace, "пространство добавлено");

        }
        private int CreateId(List<WorkSpace> workSpaces)
        {
            int lastId;
            if (workSpaces.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = workSpaces.Last().Id + 1;
            }
            return lastId;
        }
    }
}
