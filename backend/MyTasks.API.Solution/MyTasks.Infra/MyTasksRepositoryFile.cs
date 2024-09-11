using MyTasks.Domain.VO;

namespace MyTasks.Infra
{
    public class MyTasksRepositoryFile : IMyTasksRepository
    {
        public MyTaskVO MarkAsDone(long id, bool done)
        {
            throw new NotImplementedException();
        }

        public void CreateMyTask(MyTaskVO myTaskVO)
        {
        }

        public void DeleteMyTask(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MyTaskVO> GetAllMyTasks()
        {
            throw new NotImplementedException();
        }

        public MyTaskVO GetById(long id)
        {
            throw new NotImplementedException();
        }

        public MyTaskVO UpdateMyTask(MyTaskVO myTaskVO)
        {
            throw new NotImplementedException();
        }
    }
}
