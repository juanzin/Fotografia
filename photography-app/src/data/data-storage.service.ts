import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataStorageService {

  private photographerId: number = 1; // IF YOU WANT TO USE ANOTHER PHOTOGRAPHER CHANGE THE ID HERE
  private emptyImageUrl: string = "assets/emptyImage.jpg";

  constructor() {

  }

  getPhotographerId() {
    return this.photographerId;
  }

  getEmptyImageUrl() {
    return this.emptyImageUrl;
  }
}
