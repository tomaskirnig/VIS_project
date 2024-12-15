using Domain;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Presentation
{
    public partial class LogIn_Register : Window
    {
        private bool isLoginMode = true;

        public LogIn_Register()
        {
            InitializeComponent();
            UpdateMode();
        }

        private void UpdateMode()
        {
            if (isLoginMode)
            {
                ActionButton.Content = "Login";
                SwitchModeText.Text = "Don't have an account? Register";
                RegisterFields.Visibility = Visibility.Collapsed;
            }
            else
            {
                ActionButton.Content = "Register";
                SwitchModeText.Text = "Already have an account? Login";
                RegisterFields.Visibility = Visibility.Visible;
            }
        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            if (isLoginMode)
            {
                // Handle Login
                string username = UsernameInput.Text;
                string password = PasswordInput.Password;

                if (Authentication.Login(username, password))
                {
                    MessageBox.Show("Login successful!");
                    this.Close(); // Close login window
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            else
            {
                // Handle Registration
                string firstName = FirstNameInput.Text;
                string lastName = LastNameInput.Text;
                string email = EmailInput.Text;
                string username = UsernameInput.Text;
                string password = PasswordInput.Password;
                DateTime? dob = DateOfBirthInput.SelectedDate;
                string gender = (GenderInput.SelectedItem as ComboBoxItem)?.Content.ToString();

                if (!dob.HasValue)
                {
                    MessageBox.Show("Please select a valid date of birth.");
                    return;
                }

                bool success = Authentication.Register(firstName, lastName, dob.Value, email, gender, username, password, role: 0);
                if (success)
                {
                    MessageBox.Show("Registration successful!");
                    //isLoginMode = true; // Switch to login mode
                    this.Close(); 
                    UpdateMode();
                }
                else
                {
                    MessageBox.Show("Registration failed. Username may already be taken.");
                }
            }
        }

        private void SwitchModeText_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isLoginMode = !isLoginMode; // Toggle between login and register
            UpdateMode();
        }
    }
}
