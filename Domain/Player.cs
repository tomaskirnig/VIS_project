using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Country { get; set; }
        public bool GameReviewer { get; set; }

        public Player(PlayerDTO playerDTO)
        {
            MapPlayer(playerDTO);
        }

        public Player(int playerId)
        {
            PlayerDTO player = PlayerTDG.GetById(playerId);

            if (player != null)
            {
                MapPlayer(player);
            }
            else
            {
                throw new ArgumentException("Player not found");
            }
        }

        // Map method to populate fields
        public void MapPlayer(PlayerDTO playerDTO)
        {
            PlayerId = playerDTO.PlayerId;
            FirstName = playerDTO.FirstName;
            LastName = playerDTO.LastName;
            DateOfBirth = playerDTO.DateOfBirth;
            Email = playerDTO.Email;
            Gender = playerDTO.Gender;
            RegistrationDate = playerDTO.RegistrationDate;
            Country = playerDTO.Country;
            GameReviewer = playerDTO.GameReviewer;
        }

        // Update method to save changes
        public void Update()
        {
            PlayerDTO player = new PlayerDTO
            {
                PlayerId = PlayerId,
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth,
                Email = Email,
                Gender = Gender,
                RegistrationDate = RegistrationDate,
                Country = Country,
                GameReviewer = GameReviewer
            };

            PlayerTDG.Update(player);
        }

        // Static method to get all players
        public static List<Player> GetAllPlayers()
        {
            List<PlayerDTO> playersDTO = PlayerTDG.GetAll();

            if (playersDTO != null)
            {
                return playersDTO.Select(dto => new Player(dto)).ToList();
            }
            else
            {
                throw new ArgumentException("No players found");
            }
        }
    }
}
