using Disco.BLL.DTO;
using Disco.Mobile.Models;
using Disco.Mobile.Services;
using Disco.Mobile.Services.Enums;
using Disco.Mobile.Services.Rest;
using Disco.Mobile.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Disco.Mobile.ViewModels
{
    /// <summary>
    /// View Model который отвечает за работу с регистрацией, входом, и всем, что связанно с этим
    /// </summary>
    public class AccountViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Страница входа
        /// </summary>
        private StartedPage startedPage;

        /// <summary>
        /// Полное имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Nick name пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Повтор пароля
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        public string EmailError { get; set; }

        public string PasswordError { get; set; }

        public ICommand ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Команда которая выполняет вход в приложение
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// Комманда которая выполняет регистрацию в приложении
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        /// <summary>
        /// Комманда которая выполняет переход на другую страницу
        /// </summary>
        public ICommand PushRegisterCommand { get; set; }

        /// <summary>
        /// Принемает или задает комманду для кнопки Welcom
        /// </summary>
        public ICommand WelcomButton { get; set; }

        public ICommand PushToRegisterCommand { get; set; }

        /// <summary>
        /// Этот конструктор используется для страницы RegisterPage
        /// </summary>
        /// <param name="register">Страница регистрации</param>
        public AccountViewModel(RegisterPage register)
        {
            RegisterCommand = new Command(async () => await Register());
        }

        /// <summary>
        /// Этот канструктор необходим для работы со страницай входа
        /// </summary>
        /// <param name="startedPage">Страница входа</param>
        [Obsolete]
        public AccountViewModel(StartedPage startedPage)
        {
            this.startedPage = startedPage;
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(async () => await Register());
            WelcomButton = new Command(async () => await WelcomButtonClick());
            ForgotPasswordCommand = new Command(async () => await this.ForgotPassword());
            PushToRegisterCommand = new Command(async () => await this.PushToRegister());
        }

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public AccountViewModel() { }

        [Obsolete]
        private async Task ForgotPassword() =>
            await PopupNavigation.Instance.PushAsync(new ForgotPassword());

        private async Task PushToRegister() =>
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());

        /// <summary>
        /// Метод который используется для входа в приложение
        /// 
        /// </summary>
        /// <returns>Пользователя если логин и пароль верны, если же нет - возвращает сообщение, что не верно ввденно</returns>
        private async Task<UserDTO> Login()
        {
            LoginDTO dto = new LoginDTO
            {
                Email = Email,
                Password = Password
            };
            using (HttpClient client = RestClient.GetClient())
            {
                var json = JsonConvert.SerializeObject(dto);
                var loginParams = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
                var response = await client.PostAsync($"api/user/auth/login", loginParams);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<UserDTO>(content);
                    switch (result.VarificationResult)
                    {
                        case VarificationResults.EmailINotValid:
                            {
                                startedPage.emailError.IsVisible = true;
                                startedPage.emailError.Text = "Wrong E-mail";
                            }
                            break;
                        case VarificationResults.UserNotFound:
                            {
                                startedPage.emailError.IsVisible = true;
                                startedPage.emailError.Text = "Wrong E-mail";
                            }
                            break;
                        case VarificationResults.PasswordNotValid:
                            {
                                startedPage.passwordError.IsVisible = true;
                                startedPage.passwordError.Text = "Wrong password";
                            }
                            break;
                        case VarificationResults.Ok:
                            {
                                App.Current.Properties["User"] =
                                    result.User;
                                Animation Show = new Animation(async (b) =>
                                {
                                    startedPage.welcom.IsVisible = true;
                                    await startedPage.welcom.FadeTo(1, 1000);
                                });
                                Animation Fade = new Animation(async (a) => {
                                    await startedPage.password.FadeTo(0, 1000);
                                    startedPage.password.IsVisible = false;
                                    await startedPage.passwordLabel.FadeTo(0, 1000);
                                    startedPage.passwordLabel.IsVisible = false;
                                    await startedPage.passwordEntry.FadeTo(0, 1000);
                                    startedPage.passwordEntry.IsVisible = false;
                                    await startedPage.passwordError.FadeTo(0, 1000);
                                    startedPage.passwordError.IsVisible = false;
                                    await startedPage.loginButton.FadeTo(0, 1000);
                                    startedPage.loginButton.IsVisible = false;
                                    await startedPage.forgotPassword.FadeTo(0, 1000);
                                    startedPage.forgotPassword.IsVisible = false;
                                    await startedPage.register.FadeTo(0, 1000);
                                    startedPage.register.IsVisible = false;
                                    await startedPage.welcomText.FadeTo(0, 1000);
                                    startedPage.welcomText.IsVisible = false;
                                });

                                var translateEmailImage = new Animation(e => startedPage.password.TranslateTo(
                                    startedPage.password.TranslationX + 210,
                                    startedPage.password.TranslationY
                                ), 1500, easing: Easing.Linear);
                                translateEmailImage.Commit(startedPage.password, "Animation", finished: async (x, y) =>
                                {
                                    await Task.Delay(1000);
                                    await Task.Run(() => Fade.Commit(this.startedPage, "FadeAnimation", length: 1500, easing: Easing.Linear));
                                    await Task.Run(() => Show.Commit(this.startedPage, "ShowAnimation", length: 1500, easing: Easing.Linear));
                                    await Task.Delay(5000);
                                    await startedPage.Navigation.PushAsync(new MainTabbedPage());
                                });
                                return result;
                            }
                            break;
                        case VarificationResults.EmailCenNotBeNull:
                            break;
                        case VarificationResults.PasswordCanNotBeNull:
                            {
                                Animation Show = new Animation(async (b) =>
                                {
                                    startedPage.passwordEntry.IsVisible = true;
                                    await startedPage.passwordEntry.FadeTo(1, 1000);
                                    startedPage.passwordLabel.IsVisible = true;
                                    await startedPage.passwordLabel.FadeTo(1, 1000);
                                    await startedPage.passwordError.FadeTo(1, 1000);
                                });
                                Animation Fade = new Animation(async (a) => {
                                    await startedPage.email.FadeTo(0, 1000);
                                    startedPage.email.IsVisible = false;
                                    await startedPage.emailLabel.FadeTo(0, 1000);
                                    startedPage.emailLabel.IsVisible = false;
                                    await startedPage.emailEntry.FadeTo(0, 1000);
                                    startedPage.emailEntry.IsVisible = false;
                                    await startedPage.emailError.FadeTo(0, 1000);
                                    startedPage.emailError.IsVisible = false;
                                });

                                var translateEmailImage = new Animation(e => startedPage.email.TranslateTo(
                                    startedPage.email.TranslationX + 210,
                                    startedPage.email.TranslationY
                                ),  1500 , easing: Easing.Linear);
                                translateEmailImage.Commit(startedPage.email, "Animation", finished: async (x, y) =>
                                {
                                    await Task.Delay(1000);
                                    await Task.Run(() =>Fade.Commit(this.startedPage, "FadeAnimation", length: 1500, easing: Easing.Linear));
                                    await Task.Run(() => Show.Commit(this.startedPage, "ShowAnimation", length: 1500, easing: Easing.Linear));
                                });
                            }
                            break;
                        default:
                            break;
                    }
                }
                return null;
            }
        }
        
        /// <summary>
        /// Метод необзодим для регистрации нового пользователя
        /// </summary>
        /// <returns>Нового пользователя, если все правельно введено</returns>
        private async Task Register()
        {
            RegisterDTO rg = new RegisterDTO
            {
                Email = Email,
                FirstName = FirstName,
                UserName = UserName,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            };
            using (HttpClient client = RestClient.GetClient())
            {
                var json = JsonConvert.SerializeObject(rg);
                var rgParams = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
                var responce = await client.PostAsync($"api/user/auth/register", rgParams);
                if (responce.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await responce.Content.ReadAsStringAsync();
                    client.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
                    var userDTO = JsonConvert.DeserializeObject<UserDTO>(result);
                    if (userDTO.VarificationResult == VarificationResults.Ok)
                    {
                        Application.Current.Properties["User"] = userDTO.User;
                        await Application.Current.MainPage.Navigation.PushAsync(new MainTabbedPage());
                    }
                    else
                    {
                        var faildResult = await responce.Content.ReadAsStringAsync();
                        var userResult = JsonConvert.DeserializeObject<UserDTO>(faildResult);
                        await App.Current.MainPage.DisplayAlert("Error", $"{userResult.VarificationResult}", "Ok"); ; ;
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "All strings was empty", "ok");
                }
            }

        }

        private async Task WelcomButtonClick()
        {
            Animation fadeAnimation = new Animation(async c => {
                await startedPage.WelcomeButton.FadeTo(0, 1000);
                await startedPage.WelcomeButton.FadeTo(0, 1000);
                startedPage.WelcomeButton.IsVisible = false;
                await startedPage.forgotPassword.TranslateTo(
                    this.startedPage.forgotPassword.TranslationX - this.startedPage.WelcomeButton.TranslationX + this.startedPage.emailEntry.TranslationX,
                    this.startedPage.forgotPassword.TranslationY - this.startedPage.WelcomeButton.TranslationY + this.startedPage.emailEntry.TranslationY);
                startedPage.emailLabel.IsVisible = true;
                await startedPage.emailLabel.FadeTo(1, 1000);
                //startedPage.emailError.IsVisible = true;
                //await startedPage.emailError.FadeTo(1, 1000);
                startedPage.emailLabel.IsVisible = true;
                await startedPage.emailLabel.FadeTo(1, 1000);
                startedPage.emailEntry.IsVisible = true;
                await startedPage.emailEntry.FadeTo(1, 1000);
                startedPage.loginButton.IsVisible = true;
                await startedPage.loginButton.FadeTo(1, 1000);
            });
            Animation anim = new Animation();
            anim.Add(0.1, 1.0, fadeAnimation);
            anim.Commit(startedPage.WelcomeButton, "FadeAnimation", rate: 10, length: 1500, easing: Easing.Linear);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
