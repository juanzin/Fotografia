import { Component, OnDestroy, OnInit } from '@angular/core';
import { PhotoRequestsService } from '../../../data/photo-requests.service';
import { PhotographerRequestsService } from '../../../data/photographer-requests.service';
import { DataStorageService } from '../../../data/data-storage.service';

const NUMBER_CATEGORIES: number = 6;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit, OnDestroy{

  private photos: any[];
  private photographerId: number;
  public categories: any[];
  public username: string;

  constructor(
    private photoRequests: PhotoRequestsService,
    private photographerRequest: PhotographerRequestsService,
    private dataStorage: DataStorageService) {
    this.photos = [];
    this.categories = [];
    this.username = "";
    this.photographerId = dataStorage.getPhotographerId();
  }

  public loadPhotos() {
    for(let i = 0; i < NUMBER_CATEGORIES; i++) {
      // TO DO
      this.categories.push({
        name: '',
        urlPhoto: this.dataStorage.getEmptyImageUrl() 
      })
    }
  }

  getPhotographerInfo() {
     this.photographerRequest.getPhotographerInfo(this.photographerId).subscribe({
      next: (data) => {
        if(data.length > 0) {
          this.username = data[0].name + " " + data[0].materno;
        } else {
          console.error("photographer not found");
        }
      },
      error: (err) => {
        console.error('Error loading productos', err);
      }
    });
  }

  getPhotos() {
    this.photoRequests.getPhotosByUser(this.photographerId).subscribe({
      next: (data) => {
        if(data === null) {
          data = [];
        }
        this.photos = data;
        this.loadPhotos();
      },
      error: () => {
        console.error("error while retrieving photos");
      }
    });
  }

  public ngOnInit(): void {
    this.getPhotographerInfo();
    this.getPhotos();
  }

  public ngOnDestroy(): void {
    
  }

}
