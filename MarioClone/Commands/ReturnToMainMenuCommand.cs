﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioClone.Commands
{
    public class ReturnToMainMenuCommand : AbstractCommand<MarioCloneGame>
    {
        public ReturnToMainMenuCommand(MarioCloneGame receiver) : base(receiver) { }
        public override void InvokeCommand()
        {
            Receiver.ReturnToMainMenu();
        }
    }
}
