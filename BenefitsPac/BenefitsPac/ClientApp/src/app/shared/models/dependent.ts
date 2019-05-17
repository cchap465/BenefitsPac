export class Dependent {
    id: number;
    name: string;
    employeeId: number;

    constructor(id: number, name: string, employeeId: number) {
        this.id = id;
        this.name = name;
        this.employeeId = employeeId;
    }
  }