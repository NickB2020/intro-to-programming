import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { counterFeature } from './state';
import { CounterAction } from './state/actions';

@Component({
  selector: 'app-counter',
  standalone: true,
  imports: [],
  template: `
    <div>
      <button (click)="decrement()" class="btn btn-primary">-</button>
      <span>{{ current() }}</span>
      <button (click)="increment()" class="btn btn-primary">+</button>
      <div>
        <button
          [disabled]="current() === 0"
          (click)="reset()"
          class="btn btn-warning"
        >
          Reset
        </button>
      </div>
    </div>
  `,
  styles: ``,
})
export class CounterComponent {
  // private store: Store;

  // constructor(store: Store) {
  //   this.store = store;
  // }
  constructor(private store: Store) {}
  current = this.store.selectSignal(counterFeature.selectCurrent);

  increment() {
    this.store.dispatch(CounterAction.incrementedTheCount());
  }

  decrement() {
    this.store.dispatch(CounterAction.decrementedTheCount());
  }

  reset() {
    this.store.dispatch(CounterAction.countWasReset());
  }
}