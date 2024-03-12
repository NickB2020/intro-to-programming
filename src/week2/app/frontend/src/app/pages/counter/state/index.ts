import { createFeature, createReducer, on } from '@ngrx/store';
import { CounterAction } from './actions';

export interface CounterState {
  current: number;
}

const initialState: CounterState = {
  current: 0,
};

export const counterFeature = createFeature({
  name: 'counter',
  reducer: createReducer(
    initialState,
    on(CounterAction.incrementedTheCount, (state) => ({
      current: state.current + 1,
    })),
    on(CounterAction.decrementedTheCount, (state) => ({
      current: state.current - 1,
    })),
    on(CounterAction.countWasReset, () => initialState)
  ),
});