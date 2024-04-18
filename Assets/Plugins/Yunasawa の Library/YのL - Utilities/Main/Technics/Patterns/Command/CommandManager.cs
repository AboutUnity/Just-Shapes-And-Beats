using System;
using UnityEngine;
using YNL.Extension.Method;
using YNL.Technic.Singleton;
using YNL.Utilities;

namespace YNL.Technic.Command
{
    public class CommandManager : Singleton<CommandManager>
    {
        [SerializeField] private SerializableDictionary<string, Type> commandDictionary = new();

        public int GetAmount() => commandDictionary.Count;

        /// <summary>
        /// Register a new command.
        /// </summary>
        public void Register(string commandName, Type command)
        {
            if (!MType.IsSameOrSubtype(typeof(Command), command))
            {
                MDebug.Notify("Object is not Command type.");
                return;
            }
            if (commandDictionary.ContainsKey(commandName))
            {
                MDebug.Warning($"Command <color=#f29eff><b>{commandName}</b></color> is already in system.");
                return;
            }
            commandDictionary[commandName] = command;

            //MDebug.Action($"Registered: {commandName} - {command.Name}");
        }

        /// <summary>
        /// Unregister a command.
        /// </summary>
        public void Unregister(string commandName)
        {
            commandDictionary.Remove(commandName);
        }

        /// <summary>
        /// Execute command
        /// </summary>
        public void Execute(string commandName, object data = null)
        {
            Command command = (Command)Activator.CreateInstance(commandDictionary[commandName]);
            command.Data = data;
            command.Execute();
        }
    }
}