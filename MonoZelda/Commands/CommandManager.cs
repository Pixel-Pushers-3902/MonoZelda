using System.Collections.Generic;
using System.Diagnostics;
using PixelPushers.MonoZelda.Controllers;
using PixelPushers.MonoZelda.Items;

namespace PixelPushers.MonoZelda.Commands;

public enum CommandEnum
{
    // Temporary Commands for Sprint2
    BlockCycleCommand,
    EnemyCycleCommand,
    ItemCycleCommand,
    // Commands for entire project
    ExitCommand,
    PlayerAttackCommand,
    PlayerMoveCommand,
    PlayerTakeDamageCommand,
    PlayerUseItemCommand,
    ResetCommand,
    PlayerStandingCommand,
    StartGame,
    None
}

public class CommandManager
{
    Dictionary<CommandEnum, ICommand> commandMap;
    public CommandManager()
    {
        commandMap = new Dictionary<CommandEnum, ICommand>();
        AddCommand(CommandEnum.BlockCycleCommand, new BlockCycleCommand());
        AddCommand(CommandEnum.EnemyCycleCommand, new EnemyCycleCommand());
        AddCommand(CommandEnum.ItemCycleCommand, new ItemCycleCommand());
        AddCommand(CommandEnum.ExitCommand, new ExitCommand());
        AddCommand(CommandEnum.PlayerAttackCommand, new PlayerAttackCommand());
        AddCommand(CommandEnum.PlayerMoveCommand, new PlayerMoveCommand());
        AddCommand(CommandEnum.PlayerTakeDamageCommand, new PlayerTakeDamageCommand());
        AddCommand(CommandEnum.PlayerUseItemCommand, new PlayerUseItemCommand());
        AddCommand(CommandEnum.PlayerStandingCommand, new PlayerStandingCommand());
        AddCommand(CommandEnum.ResetCommand, new ResetCommand());
        AddCommand(CommandEnum.StartGame, new GameStartCommand());
    }

    public Dictionary<CommandEnum, ICommand> CommandMap
    {
        get
        {
            return commandMap;
        }
    }

    public GameState Execute(CommandEnum commandName)
    {
        return commandMap[commandName].Execute();
    }

    public bool ReplaceCommand(CommandEnum commandName, ICommand command)
    {
        if (commandMap.ContainsKey(commandName))
        {
            commandMap[commandName] = command;
            return true;
        }
        else
        {
            Debug.WriteLine("Command with same enum name not present in the dictionary.");
            return false;
        }
    }

    public bool AddCommand(CommandEnum commandName, ICommand command)
    {
        if (commandMap.ContainsKey(commandName))
        {
            Debug.WriteLine("Command with same enum name already present in the dictionary.");
            return false;
        }
        else
        {
            commandMap[commandName] = command;
            return true;
        }
    }

    public void SetController(IController controller)
    {
        foreach (ICommand command in commandMap.Values)
        {
            command.SetController(controller);
        }
    }
}