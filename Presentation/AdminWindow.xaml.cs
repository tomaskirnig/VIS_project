using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Domain;

namespace Presentation
{
    public partial class AdminWindow : Window
    {
        private List<Player> players;

        public AdminWindow()
        {
            InitializeComponent();
            LoadPlayers();
        }

        private void LoadPlayers()
        {
            players = Player.GetAllPlayers(); // Fetch all players from the database
            PlayersDataGrid.ItemsSource = players;
        }

        private void EditPlayer_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlayer = (Player)PlayersDataGrid.SelectedItem;
            if (selectedPlayer != null)
            {
                var editWindow = new EditWindow(selectedPlayer, updatedPlayer =>
                {
                    // Find and update the player in the players list
                    var originalPlayer = players.FirstOrDefault(p => p.PlayerId == updatedPlayer.PlayerId);
                    if (originalPlayer != null)
                    {
                        originalPlayer.FirstName = updatedPlayer.FirstName;
                        originalPlayer.LastName = updatedPlayer.LastName;
                        originalPlayer.Email = updatedPlayer.Email;
                        originalPlayer.Role = updatedPlayer.Role;
                        originalPlayer.Gender = updatedPlayer.Gender;
                        originalPlayer.DateOfBirth = updatedPlayer.DateOfBirth;
                    }

                    // Refresh the DataGrid
                    PlayersDataGrid.ItemsSource = null; // Detach the source
                    PlayersDataGrid.ItemsSource = players; // Reattach the source
                });

                editWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a player to edit.");
            }
        }


        private void DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlayer = (Player)PlayersDataGrid.SelectedItem;
            if (selectedPlayer != null)
            {
                // Logic for deleting a player
                MessageBox.Show($"Delete player: {selectedPlayer.UserName}");
                players.Remove(selectedPlayer); // Simulate deletion
                PlayersDataGrid.ItemsSource = null;
                PlayersDataGrid.ItemsSource = players; // Refresh the grid
            }
            else
            {
                MessageBox.Show("Please select a player to delete.");
            }
        }
    }
}
