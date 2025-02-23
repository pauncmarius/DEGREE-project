import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-directional-button',
  standalone: true,
  imports: [],
  templateUrl: './directional-button.component.html',
  styleUrl: './directional-button.component.scss'
})

export class DirectionalButtonComponent implements OnInit {
  @Output() changeDirection = new EventEmitter<number>();
  @Input() directionIncrese: number = 0;

  direction: string = '';
  constructor() {}
  ngOnInit(): void {
    this.direction = this.directionIncrese >= 0 ? '>' : '<';
  }

  onChangeDirection() {
    this.changeDirection.emit(this.directionIncrese);
  }
}
