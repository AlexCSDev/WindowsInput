﻿using System;
using System.Collections.Generic;
using WindowsInput.Native;

namespace WindowsInput.Events {
    public class KeyUp : KeyEvent {

        public KeyUp(KeyCode Key, bool? Extended = default) : base(Key, Extended) {
            Initialize(CreateChildren());
        }

        private IEnumerable<IEvent> CreateChildren() {
            yield return new RawInput(new KEYBDINPUT() {
                KeyCode = Key,
                ScanCode = (byte)NativeMethods.MapVirtualKey((byte)Key, 0),
                Flags = (Extended
                    ? KeyboardFlag.KeyUp | KeyboardFlag.ExtendedKey
                    : KeyboardFlag.KeyUp
                    ) | KeyboardFlag.ScanCode,
            });
        }

    }

}
