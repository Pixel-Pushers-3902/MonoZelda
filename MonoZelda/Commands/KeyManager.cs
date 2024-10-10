using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelPushers.MonoZelda.Commands;

namespace PixelPushers.MonoZelda.Commands;

public enum OneShot
{
    YES,
    NO,
}

public class KeyManager
{
    private CommandManager commandManager;
    private Dictionary<Tuple<Keys,OneShot>,ICommand> keyCommandDictionary;

    public Dictionary<Tuple<Keys,OneShot>, ICommand> KeyCommandDictionary
    {
        get
        {
            return keyCommandDictionary;
        }
    }

    public KeyManager(CommandManager commandManager)
    {
        this.commandManager = commandManager;
        keyCommandDictionary = new Dictionary<Tuple<Keys,OneShot>, ICommand>
        {
            {Tuple.Create(Keys.W,OneShot.NO),(PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand]},
            {Tuple.Create(Keys.Up,OneShot.NO),(PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand]},
            {Tuple.Create(Keys.S,OneShot.NO),(PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand]},
            {Tuple.Create(Keys.Down, OneShot.NO),(PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand]},
            {Tuple.Create(Keys.D, OneShot.NO),(PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand]},
            {Tuple.Create(Keys.Right, OneShot.NO),(PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand]},
            {Tuple.Create(Keys.A, OneShot.NO)   ,(PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand]},
            {Tuple.Create(Keys.Left, OneShot.NO),(PlayerMoveCommand)commandManager.CommandMap[CommandEnum.PlayerMoveCommand]},
            {Tuple.Create(Keys.D1, OneShot.YES),(PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand]},
            {Tuple.Create(Keys.D2, OneShot.YES),(PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand]},
            {Tuple.Create(Keys.D3, OneShot.YES),(PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand]},
            {Tuple.Create(Keys.D4, OneShot.YES),(PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand]},
            {Tuple.Create(Keys.D5, OneShot.YES),(PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand]},
            {Tuple.Create(Keys.D6, OneShot.YES),(PlayerUseItemCommand)commandManager.CommandMap[CommandEnum.PlayerUseItemCommand]},
            {Tuple.Create(Keys.Z, OneShot.YES),(PlayerAttackCommand)commandManager.CommandMap[CommandEnum.PlayerAttackCommand]},
            {Tuple.Create(Keys.N, OneShot.YES),(PlayerAttackCommand)commandManager.CommandMap[CommandEnum.PlayerAttackCommand]},
            {Tuple.Create(Keys.Q, OneShot.NO),(ExitCommand)commandManager.CommandMap[CommandEnum.ExitCommand]},
            {Tuple.Create(Keys.R, OneShot.NO),(ResetCommand)commandManager.CommandMap[CommandEnum.ResetCommand]},
            {Tuple.Create(Keys.None, OneShot.NO),(PlayerStandingCommand)commandManager.CommandMap[CommandEnum.PlayerStandingCommand]},
        };
    }
}
