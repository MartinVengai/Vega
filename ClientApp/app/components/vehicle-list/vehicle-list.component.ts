import { VehicleService } from './../../services/vehicle.service';
import { Vehicle } from './../../models/vehicle';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[];
  makes: any[];
  filter: any = {};

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.populateVehicles();
  }

  onFilterChange() {
    this.populateVehicles();
  }

  populateVehicles() {
    this.vehicleService.getVehicles(this.filter).subscribe(vehicles => this.vehicles = vehicles);
    this.vehicleService.getMakes().subscribe(makes => this.makes = makes);
  }

  resetFilter() {
    this.filter = {};
    this.onFilterChange();
  }

}
