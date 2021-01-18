using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            try
            {
                GetMessageForModel(userId, description);
            }
            catch (Exception e)
            {
                model.AddAttribute("action_result", e.Message);
                return false;
            }

            return true;
        }

        private void GetMessageForModel(int userId, string description)
        {
            var task = new UserTask(description);

            try
            {
                _taskService.AddTaskForUser(userId, task);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
