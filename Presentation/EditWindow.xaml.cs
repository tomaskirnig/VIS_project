﻿using System;
using System.Windows;
using Domain;

namespace Presentation
{
    public partial class EditWindow : Window
    {
        private Player player;
        private Action<Player> onPlayerUpdated;

        public EditWindow(Player selectedPlayer, Action<Player> onPlayerUpdatedCallback)
        {
            InitializeComponent();
            player = selectedPlayer;
            onPlayerUpdated = onPlayerUpdatedCallback;
            LoadPlayerData();
        }

        private void LoadPlayerData()
        {
            FirstNameTextBox.Text = player.FirstName;
            LastNameTextBox.Text = player.LastName;
            EmailTextBox.Text = player.Email;
            UsernameTextBox.Text = player.UserName;
            PasswordBox.Text = player.Password;
            RoleComboBox.SelectedIndex = player.Role;
            DateOfBirthPicker.SelectedDate = player.DateOfBirth;

            if (player.Gender == 'M') GenderComboBox.SelectedIndex = 0;
            else if (player.Gender == 'F') GenderComboBox.SelectedIndex = 1;
            else GenderComboBox.SelectedIndex = 2;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Update player details
                player.FirstName = FirstNameTextBox.Text;
                player.LastName = LastNameTextBox.Text;
                player.Email = EmailTextBox.Text;
                player.Role = RoleComboBox.SelectedIndex;
                player.UserName = UsernameTextBox.Text;
                player.Password = PasswordBox.Text;
                player.DateOfBirth = DateOfBirthPicker.SelectedDate.Value;
                player.Gender = GenderComboBox.SelectedIndex switch
                {
                    0 => 'M',
                    1 => 'F',
                    _ => 'O'
                };

                // Save changes to the database
                player.Update();

                // Notify parent window about the updated player
                onPlayerUpdated?.Invoke(player);

                MessageBox.Show("Player updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating player: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
