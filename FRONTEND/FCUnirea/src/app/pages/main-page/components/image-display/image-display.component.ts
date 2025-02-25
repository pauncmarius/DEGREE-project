import { Component, Input, OnInit } from '@angular/core';
import { Photo } from '../../services/models/Photo';

@Component({
  selector: 'app-image-display',
  standalone: true,
  imports: [],
  templateUrl: './image-display.component.html',
  styleUrl: './image-display.component.scss'
})

export class ImageDisplayComponent implements OnInit {
  @Input() imageData?: Photo;

  constructor() {}

  ngOnInit(): void {}
}
