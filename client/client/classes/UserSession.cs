using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.classes
{
    public class UserSession
    {
        private static UserSession _instance;
        private static readonly object _lock = new object();

        public string UserId { get; private set; }

        private UserSession() { }

        public static UserSession Instance
        {
            get
            {
                // 이중 잠금 방식으로 스레드 안전성을 보장
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserSession();
                        }
                    }
                }
                return _instance;
            }
        }

        public void SetUserId(string userId)
        {
            UserId = userId;
        }
    }

}
