using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPF_TimeTracker
{
    public class FirebaseService
    {
        private readonly FirebaseClient _firebaseClient;

        public FirebaseService()
        {
            _firebaseClient = new FirebaseClient("https://wpftimetracker.firebaseio.com/");
        }

        // Метод для сохранения таймера
        public async Task SaveTimer(TimerModel timer)
        {
            await _firebaseClient
                .Child("Timers")
                .PostAsync(timer);
        }

        // Метод для получения всех таймеров
        public async Task<List<TimerModel>> GetTimers()
        {
            var timers = await _firebaseClient
                .Child("Timers")
                .OnceAsync<TimerModel>();

            return timers.Select(item => item.Object).ToList();
        }

        // // Другие методы для работы с Firebase

        // // Метод для сохранения категории
        public async Task SaveCategory(CategoryModel category)
        {
            await _firebaseClient
                .Child("Categories")
                .PostAsync(category);
        }

        // // Метод для получения всех категорий

        public async Task<List<CategoryModel>> GetCategories()
        {
            var categories = await _firebaseClient
                .Child("Categories")
                .OnceAsync<CategoryModel>();

            return categories.Select(item => item.Object).ToList();
        }

        //  // Метод для сохранения записи времени

        public async Task SaveTimeEntry(TimeEntryModel timeEntry)
        {
            await _firebaseClient
                .Child("TimeEntries")
                .PostAsync(timeEntry);
        }

        // // Метод для получения всех записей времени
        public async Task<List<TimeEntryModel>> GetTimeEntries()
        {
            var timeEntries = await _firebaseClient
                .Child("TimeEntries")
                .OnceAsync<TimeEntryModel>();

            return timeEntries.Select(item => item.Object).ToList();
        }

    }

}
