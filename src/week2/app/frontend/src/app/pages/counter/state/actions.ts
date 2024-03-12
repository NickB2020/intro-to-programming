import { createActionGroup, emptyProps } from '@ngrx/store';

export const CounterAction = createActionGroup({
  source: 'Counter Component Events',
  events: {
    'Incremented The Count': emptyProps(),
    'Decremented The Count': emptyProps(),
    'Count was Reset': emptyProps(),
  },
});