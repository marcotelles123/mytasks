using MyTasks.Domain.VO;

namespace MyTasks.Infra
{
    public interface IMyTasksRepository
    {
        void CreateMyTask(MyTaskVO myTaskVO);
        IEnumerable<MyTaskVO> GetAllMyTasks();
        MyTaskVO GetById(long id);
        MyTaskVO UpdateMyTask(MyTaskVO myTaskVO);
        void DeleteMyTask(long id);
        MyTaskVO MarkAsDone(long id, bool done);
    }
}
