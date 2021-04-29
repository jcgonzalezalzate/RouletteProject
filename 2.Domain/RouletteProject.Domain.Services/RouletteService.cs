namespace RouletteProject.Domain.Services
{
    using Entities;
    using Entities.Enums;
    using Interfaces.Repositories;
    using Interfaces.Services;
    using System;
    using System.Collections.Generic;

    public class RouletteService : IRouletteService
    {
        protected readonly IDynamoRepository DynamoRepository;

        public RouletteService(IDynamoRepository rouletteRepository)
        {
            DynamoRepository = rouletteRepository;
        }

        public bool IsValidRouletteToOpen(Roulette roulette)
        {
            if (roulette.State != RouletteState.Created)
            {
                throw new Exception(
                    $"La ruleta se encuentra en un estado incorrecto para ser abierta. State: {roulette.State}");
            }

            return true;
        }

        public Roulette CloseRoulette(Roulette roulette)
        {
            roulette.WinningNumber = new Random().Next(0, 36);
            roulette.WinningColour = roulette.WinningNumber % 2 == 0 ? Colour.Red : Colour.Black;

            foreach (var bet in roulette.Bets)
            {
                if (bet.NumberToBet == roulette.WinningNumber)
                {
                    bet.WasWinner = true;
                }

                if (bet.ColourToBet == roulette.WinningColour)
                {
                    bet.WasWinner = true;
                }
            }
            
            return roulette;
        }
    }
}
