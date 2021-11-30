using System;
using System.Collections.Generic;
using WindowsInput.Native;


namespace WindowsInput.Events {
    public class KeyDown : KeyEvent {

        public KeyDown(KeyCode Key, bool? Extended = default) : base(Key, Extended) {
            Initialize(CreateChildren());
        }

        private IEnumerable<IEvent> CreateChildren() {
            yield return new RawInput(new KEYBDINPUT() {
                KeyCode = Key,
                ScanCode = (UInt16)NativeMethods.MapVirtualKey((UInt16)Key, 0),
                Flags = (this.Extended
                    ? KeyboardFlag.KeyDown | KeyboardFlag.ExtendedKey
                    : KeyboardFlag.KeyDown
                    ),
            });
        }

    }

}
