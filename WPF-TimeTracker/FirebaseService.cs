using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TimeTracker
{
    public class FirebaseService
    {
        private readonly FirebaseClient _firebaseClient;

        public FirebaseService()
        {
            _firebaseClient = new FirebaseClient("https://wpftimetracker.firebaseapp.com");
        }

        public async Task SaveTimer(TimerModel timer)
        {
            await _firebaseClient.Child("Timers").PostAsync(timer);
        }

        public async Task<List<TimerModel>> GetTimers()
        {
            return (await _firebaseClient.Child("Timers").OnceAsync<TimerModel>()).Select(item => item.Object).ToList();
        }

        // Другие методы для работы с Firebase
    }

}
