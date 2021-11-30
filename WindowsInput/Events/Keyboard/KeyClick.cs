using System.Collections.Generic;

namespace WindowsInput.Events {
    public class KeyClick : KeyEvent {
        public KeyClick(KeyCode Key, bool? Extended = default) : base(Key, Extended) {
            Initialize(CreateChildren());
        }

        private IEnumerable<IEvent> CreateChildren() {
            return new IEvent[] {
                new KeyDown(Key, Extended),
                new Wait(300),
                new KeyUp(Key, Extended),
            };
        }


    }

}
