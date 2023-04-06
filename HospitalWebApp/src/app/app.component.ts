import { Component } from '@angular/core';
import {
  trigger,
  state,
  style,
  animate,
  transition,
  // ...
} from '@angular/animations';
@Component({
  selector: 'app-root',
  template: `
  <router-outlet></router-outlet>
`,
  styleUrls: ['./app.component.css'],
  animations: [
    // animation triggers go here
  ]
})
export class AppComponent {
  title = 'hospital-managerment-web-app';
}
