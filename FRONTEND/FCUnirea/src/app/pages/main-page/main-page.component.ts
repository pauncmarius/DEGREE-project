import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DirectionalButtonComponent } from "./components/directional-button/directional-button.component";
import { ImageDisplayComponent } from "./components/image-display/image-display.component";
import { Photo } from './services/models/Photo';

@Component({
  selector: 'app-main-page',
  standalone: true, // Adăugat pentru a permite importul direct
  imports: [CommonModule, DirectionalButtonComponent, ImageDisplayComponent], // Importă CommonModule pentru a avea acces la directivele Angular
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.scss',
})

export class MainPageComponent implements OnInit {
  constructor() {}

  @Input() images: Photo[] = [];
  @Input() totalImages: number = 0;
  @Input() imagesIndex: number = 0;
  @Output() imagesIndexChange = new EventEmitter<number>();

  ngOnInit(): void {
    this.totalImages = this.images.length;
  }

  changeIndex(incrementer: number) {
    this.imagesIndexChange.emit(
      this.imagesIndex == -1
        ? this.totalImages
        : (this.imagesIndex + incrementer) % this.totalImages
    );
  }
}
