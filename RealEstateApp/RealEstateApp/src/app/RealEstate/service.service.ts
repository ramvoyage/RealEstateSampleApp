import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RealEstateService {

  constructor(private _http: Http) { }

  myBaseUrl: string = "http://localhost:50384/RealEstates"

  searchstr = {
    value: ''
  };


  get() {
    return this._http.get('http://localhost:50384/RealEstates/List')
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  search(query) {

    this.searchstr.value = query;

    return this._http.post('http://localhost:50384/RealEstates/Search/' , this.searchstr)
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }

  getById(id: number) {
    return this._http.get('http://localhost:50384/RealEstates/GetById/' + id)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }


  edit(id: number) {
    return this._http.get('http://localhost:50384/RealEstates/Edit/' + id)
      .map((response: Response) => response)
      .catch(this.errorHandler)
  }

  save(data) {
    return this._http.post('http://localhost:50384/RealEstates/Create', data)
      .map((response: Response) => response.json())
      .catch(this.errorHandler)
  }


  update(data) {
    return this._http.post('http://localhost:50384/RealEstates/Edit/', data)
      .map((response: Response) => response.json())
      .catch(this.errorHandler);
  }


  errorHandler(error: Response) {
    console.log(error);
    return Observable.throw(error);
  }  
}
