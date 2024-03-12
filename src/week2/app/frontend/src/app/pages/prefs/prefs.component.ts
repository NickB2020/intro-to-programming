import { Component } from '@angular/core';

@Component({
  selector: 'app-prefs',
  standalone: true,
  imports: [],
  template: `
    <div class="join">
      <button disabled class="btn join-item">Count by 1</button>
      <button class="btn join-item">Count by 2</button>
      <button class="btn join-item">Count by 3</button>
    </div>
  `,
  styles: ``,
})
export class PrefsComponent {}
