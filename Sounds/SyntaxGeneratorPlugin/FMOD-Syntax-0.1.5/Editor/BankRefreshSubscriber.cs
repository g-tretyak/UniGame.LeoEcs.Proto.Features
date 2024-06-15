using FMODUnity;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace RoyTheunissen.FMODSyntax
{
    public static class BankRefreshSubscriber
    {
        private static bool _isSubscribeToRefreshEvent;

#if UNITY_EDITOR
        [InitializeOnLoadMethod]
        public static void SubscribeToRefresh()
        {
            if (!_isSubscribeToRefreshEvent)
            {
                //BankRefresher.BankRefreshed += FmodCodeGenerator.GenerateCode;
                //If you want to use automatic refresh, you should change BankRefresher.cs with adding following code
                /*
                        public static event Action BankRefreshed;
                 
                         public static void HandleBankRefresh(string result)
                        {
                            lastSourceFileChange = float.MaxValue;
                            BankRefreshWindow.HandleBankRefresh(result);
                            BankRefreshed?.Invoke();
                        }
                 */
                _isSubscribeToRefreshEvent = true;
            }
        }
#endif
    }
}