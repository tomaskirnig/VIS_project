using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation
{
    public partial class LandingPage : Window
    {
        public LandingPage()
        {
            InitializeComponent();
            LoadGames(0, 9);
            UpdatePageContent();
        }

        private void Katalog_Click(object sender, RoutedEventArgs e)
        {
            LoadGames(0, 9);
        }

        private void Knihovna_Click(object sender, RoutedEventArgs e)
        {
            GamesGrid.Children.Clear();
            GamesGrid.Columns = 2;
            GamesGrid.Rows = 1;

            // Check if a user is logged in
            var currentUser = Authentication.GetCurrentUser();
            if (currentUser == null)
            {
                // Display login prompt in a single column
                GamesGrid.Columns = 1;
                GamesGrid.Children.Add(new TextBlock
                {
                    Text = "Please log in to view your library.",
                    FontSize = 16,
                    Foreground = Brushes.Red,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                });
                return;
            }

            var purchasedGames = currentUser.PurchaseHistory.Select(p => new Game(p.GameId)).ToList();

            // LEFT PANEL: List of games
            StackPanel leftPanel = new StackPanel
            {
                Background = new SolidColorBrush(Color.FromRgb(45, 45, 45)),
                VerticalAlignment = VerticalAlignment.Stretch
            };

            foreach (var game in purchasedGames)
            {
                var gameButton = new Button
                {
                    Content = game.Title,
                    Tag = game, // Store the Game object for later retrieval
                    Background = Brushes.DarkSlateBlue,
                    Foreground = Brushes.White,
                    BorderThickness = new Thickness(0),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Margin = new Thickness(2)
                };

                // Handle game click to show details
                gameButton.Click += (s, args) =>
                {
                    var selectedGame = (Game)((Button)s).Tag;
                    UpdateRightPanel(selectedGame);
                };

                leftPanel.Children.Add(gameButton);
            }

            GamesGrid.Children.Add(leftPanel);

            // RIGHT PANEL: Placeholder for game details
            Grid rightPanel = new Grid();
            rightPanel.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) }); 
            rightPanel.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }); 

            // Top Segment
            Border topSegment = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(200, 200, 200)),
                Child = new TextBlock
                {
                    Text = "Picture",
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
            Grid.SetRow(topSegment, 0);
            rightPanel.Children.Add(topSegment);

            // Bottom Segment
            Border bottomSegment = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(240, 240, 240)),
                Child = new TextBlock
                {
                    Text = "Select a game to view details.",
                    FontSize = 14,
                    Foreground = Brushes.Gray,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
            Grid.SetRow(bottomSegment, 1);
            rightPanel.Children.Add(bottomSegment);

            GamesGrid.Children.Add(rightPanel);
        }

        private void UpdateRightPanel(Game game)
        {
            var rightPanel = GamesGrid.Children.OfType<Grid>().FirstOrDefault();
            if (rightPanel == null) return;

            var bottomSegment = rightPanel.Children.OfType<Border>().FirstOrDefault(b => Grid.GetRow(b) == 1);
            if (bottomSegment != null)
            {
                bottomSegment.Child = new StackPanel
                {
                    Margin = new Thickness(10),
                    Children =
            {
                new TextBlock
                {
                    Text = $"Title: {game.Title}",
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(5)
                },
                new TextBlock
                {
                    Text = $"Publisher: {game.Publisher}",
                    FontSize = 14,
                    Margin = new Thickness(5)
                },
                new TextBlock
                {
                    Text = $"Release Date: {game.ReleaseDate:MMMM dd, yyyy}",
                    FontSize = 14,
                    Margin = new Thickness(5)
                },
                new TextBlock
                {
                    Text = $"Price: ${game.Price}",
                    FontSize = 14,
                    Margin = new Thickness(5)
                },
                new TextBlock
                {
                    Text = $"Minimum Age: {game.MinimumAge}+",
                    FontSize = 14,
                    Margin = new Thickness(5)
                }
            }
                };
            }
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            GamesGrid.Columns = 1;
            GamesGrid.Children.Clear();

            var currentUser = Authentication.GetCurrentUser();

            if (currentUser != null)
            {
                StackPanel profilePanel = new StackPanel
                {
                    Margin = new Thickness(10),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                profilePanel.Children.Add(new TextBlock
                {
                    Text = $"Welcome, {currentUser.FirstName} {currentUser.LastName}!",
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 0, 0, 10),
                    TextAlignment = TextAlignment.Center
                });

                profilePanel.Children.Add(new TextBlock
                {
                    Text = $"Username: {currentUser.UserName}",
                    FontSize = 14,
                    TextAlignment = TextAlignment.Center
                });

                profilePanel.Children.Add(new TextBlock
                {
                    Text = $"Email: {currentUser.Email}",
                    FontSize = 14,
                    TextAlignment = TextAlignment.Center
                });

                profilePanel.Children.Add(new TextBlock
                {
                    Text = $"Role: {(currentUser.Role == 0 ? "Player" : "Admin")}",
                    FontSize = 14,
                    TextAlignment = TextAlignment.Center
                });

                Grid.SetColumn(profilePanel, 1);

                GamesGrid.Children.Add(profilePanel);
            }
            else
            {
                var loginMessage = new TextBlock
                {
                    Text = "Please log in to view your profile.",
                    FontSize = 16,
                    Foreground = Brushes.Red,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                Grid.SetColumn(loginMessage, 1);

                GamesGrid.Children.Add(loginMessage);
            }
        }

        private void Nastaveni_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new NastaveniPage());
        }

        private void LoadGames(int from, int to)
        {
            var gamesToShow = Game.GetNGames(from, to);

            // Clear existing children
            GamesGrid.Children.Clear();
            GamesGrid.Columns = 3;
            // We have 3 columns, so calculate how many rows we need:
            int columns = 3;
            int totalGames = gamesToShow.Count();
            int rows = (int)Math.Ceiling((double)totalGames / columns);

            // Set the rows dynamically
            GamesGrid.Rows = rows;

            // Populate the grid
            foreach (var game in gamesToShow)
            {
                var gameBorder = new Border
                {
                    BorderBrush = new SolidColorBrush(Colors.LightGray),
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(5),
                    Background = new SolidColorBrush(Color.FromRgb(45, 45, 45)),
                    MinHeight = 200, 
                    MinWidth = 100
                };

                var stackPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                var nameText = new TextBlock
                {
                    Text = game.Title,
                    Foreground = new SolidColorBrush(Color.FromRgb(85, 98, 243)),
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                stackPanel.Children.Add(nameText);

                gameBorder.Child = stackPanel;
                GamesGrid.Children.Add(gameBorder);
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var currUser = Authentication.GetCurrentUser();
            if (currUser != null)
            {
                Authentication.Logout(currUser.UserName);
                MessageBox.Show("You have been logged off.");
                UpdatePageContent();
            }
            else
            {
                var loginWindow = new LogIn_Register();
                loginWindow.ShowDialog();
                UpdatePageContent();
            }
        }

        private void UpdatePageContent()
        {
            if (Authentication.GetCurrentUser() != null)
            {
                LoginLogoutButton.Content = "Logout";

                var currentUser = Authentication.GetCurrentUser();
                if (currentUser.Role == 1 || currentUser.Role == 2) // 1 = Admin, 2 = Analyst
                {
                    // Add Analyze Button dynamically
                    var analyzeButton = new Button
                    {
                        Content = "Analyze",
                        Width = 100,
                        Margin = new Thickness(5),
                        Background = new SolidColorBrush(Color.FromRgb(85, 98, 243)),
                        Foreground = Brushes.White,
                        FontWeight = FontWeights.Bold,
                        Cursor = Cursors.Hand
                    };

                    analyzeButton.Click += Analyze_Click;
                    HeaderPanel.Children.Add(analyzeButton); 
                }

                LoadGames(0, 9);
            }
            else
            {
                LoginLogoutButton.Content = "Login";
                LoadGames(0, 9);
            }
        }

        private void Analyze_Click(object sender, RoutedEventArgs e)
        {
            AnalyzeWindow analyzeWindow = new AnalyzeWindow();
            analyzeWindow.ShowDialog();
        }
    }
}
