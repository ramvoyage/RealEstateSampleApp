import { Component, OnInit } from '@angular/core';
import { RealEstateService } from '../service.service';
import { Router } from '@angular/router';
import { Http, Response } from '@angular/http';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  searchField: FormControl = new FormControl();
  public list: any[] = [];

  constructor(public http: Http,
    private _router: Router,
    private _realEstateService: RealEstateService) { }

  ngOnInit() {

    //autocomplete the field
    this.searchField.valueChanges
      .subscribe(queryField => this._realEstateService.search(this.searchField.value)
        .subscribe(response => this.list = response))

    this.getList();
  }

  //get list of real estate Property
  getList() {
    this._realEstateService.get().subscribe(
      data => this.list = data
    );

  }

  //search list of properties
  searchList(msg: string) {
    
    this.searchField.valueChanges
      .subscribe(queryField => this._realEstateService.search(queryField)
        .subscribe(response => this.list = response))
        
  }

  // redirect to Edit
  gotoEdit(nav, id) {
    //this._router.navigate([nav, id]);

    window.location.href = "http://localhost:50384/RealEstates/Edit/" + id;
  }


  gotoCreate() {

    window.location.href = "http://localhost:50384/RealEstates/Create";

  }
  
}
