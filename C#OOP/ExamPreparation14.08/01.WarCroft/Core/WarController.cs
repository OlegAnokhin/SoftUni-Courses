using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characters;
        private List<Item> items;
        public WarController()
        {
            characters = new List<Character>();
            items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            Character character = null;
            var characterType = args[0];
            var name = args[1];
            if (characterType == nameof(Warrior))
            {
                character = new Warrior(name);
            }
             else if (characterType == nameof(Priest))
            {
                character = new Priest(name);
            }
            else //if (characterType != "Warrior" && characterType != "Priest")
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
            characters.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            Item item = null;
            var itemName = args[0];
            if (itemName == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else if (itemName == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.InvalidItem, itemName));
            }
            items.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var currCharacter = characters.FirstOrDefault(c => c.Name == characterName);
            if (currCharacter == null)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (items.Count <= 0)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.ItemPoolEmpty));
            }
            var currItem = items.LastOrDefault();
            currCharacter.Bag.AddItem(currItem);
            //items.RemoveAt(items.Count-1);
            return string.Format(SuccessMessages.PickUpItem, characterName, currItem.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];
            var currCharacter = characters.FirstOrDefault(c => c.Name == characterName);
            if (currCharacter == null)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            var currItem = currCharacter.Bag.GetItem(itemName);
            currCharacter.UseItem(currItem);
            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            var sb = new StringBuilder();
            var orderedList = characters.OrderByDescending(c => c.IsAlive)
                                        .ThenByDescending(h => h.Health);
            foreach (var character in orderedList)
            {
                var liveStatus = character.IsAlive == true ? "Alive" : "Dead";
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {liveStatus}");
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];
            var currAttacker = characters.FirstOrDefault(c => c.Name == attackerName);
            var currReceiver = characters.FirstOrDefault(c => c.Name == receiverName);
            if (currAttacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (currReceiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }
            if (currAttacker.GetType().Name != nameof(Warrior))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
            Warrior attacker = currAttacker as Warrior;
            attacker.Attack(currReceiver);
            var sb = new StringBuilder();
            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName,
                currAttacker.AbilityPoints, receiverName, currReceiver.Health, currReceiver.BaseHealth, currReceiver.Armor, currReceiver.BaseArmor));
            if (currReceiver.IsAlive == false)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }
            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];
            var currHealer = characters.FirstOrDefault(c => c.Name == healerName);
            var currHealing = characters.FirstOrDefault(c => c.Name == healingReceiverName);
            if (currHealer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (currHealing == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }
            if (currHealer.GetType().Name != nameof(Priest))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
            Priest healer = currHealer as Priest;
            healer.Heal(currHealing);
            var sb = new StringBuilder();
            sb.AppendLine(string.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, currHealer.AbilityPoints,
                healingReceiverName, currHealing.Health));
            return sb.ToString().TrimEnd();
        }
    }
}
