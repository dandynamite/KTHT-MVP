using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using Client.View;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace Client.Presenter
{
    class PresenterImp : IPresenter
    {
        String BASE_URL = "http://localhost:51009/";
        HttpClient httpClient;
        IView view;
        public PresenterImp(IView view)
        {
            this.view = view;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BASE_URL);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
        }

        public async void addStudent(Student student)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/Students", student);
            if (response.IsSuccessStatusCode)
            {
                viewStudent();
            }
            else view.error("them sinh vien that bai");
        }
 
        public async void deleteStudent(int id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync( "api/Students/" + id);
            if (response.IsSuccessStatusCode)
            {
                viewStudent();
            }
            else view.error("xoa sinh vien that bai");
        }

        public Student getStudent(int id)
        {
            Student student = null;
            String uri = "api/Students/" + id;
            HttpResponseMessage response = httpClient.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<Student>(json);
            }
            return student;
        }

        public async void updateStudent(Student student)
        {
            String uri = "api/Students/" + student.Id;
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(uri, student);
            if (response.IsSuccessStatusCode)
            {
                viewStudent();
            }

        }

        public async void viewClass()
        {
            String uri = "api/Lops";
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                view.updateView(json, "Lop");
            }
        }

        public async void viewStudent()
        {
            String uri = "api/Students";
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                view.updateView(json, "Student");
            }

        }
    }
}
