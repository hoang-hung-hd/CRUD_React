import React, { Component } from 'react';
import EmployeeModal  from './CreateEmployee';
import { Table, Button } from 'reactstrap';
//import { Link } from 'react-router-dom';
import './NavMenu.css';


export class EmployeeTable extends Component {
    constructor(props) {
        super(props);
        this.state = { empList: [], loading: true };
        this.GetData();
        
    }
    GetData() {
        var response = fetch("/api/employee", {
            method: "GET"
        })
            .then(response => response.json())
            .then(data => {
                this.setState({ empList: data, loading: false });
            })
            .catch((err) => {
                console.log(err.message);
            });
    }
    handleDelete(id) {
        console.log("Delete", id);
        if (window.confirm("Do you want to delete employee with Id: " + id))
            fetch('api/employee/' + id, { method: 'delete' })
                .then(this.GetData())            
        else {
            return; 
        }
    }

     handleEdit(id) {
        console.log("Edit", id);
        var response = fetch("/api/employee/"+id, {
            method: "GET"
        })
            .then(response => response.json())
            .then(data => {
                console.log(data);
            })
        //this.props.history.push("/employee/edit/" + id);
    }  

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderEmployeeTable(this.state.empList);
        return (
            <div>
                <h1 id="tabelLabel" >Employee List</h1>
                <EmployeeModal />
                {contents}
            </div>
        )
    }

     renderEmployeeTable(empList) {
        return (
            <Table hover className='table table-employee' aria-labelledby="tableEmployee">
                <thead>
                    <tr>
                        <th>Employee Name</th>
                        <th>Employee City</th>
                        <th>Department</th>
                        <th>Employee Gender</th>
                        <th> Action</th>
                    </tr>
                </thead>
                <tbody>
                    {empList.map(emp =>
                        <tr key={emp.employeeId}>
                            <td>{emp.employeeName}</td>
                            <td>{emp.cityId}</td>
                            <td>{emp.department}</td>
                            <td>{emp.gender}</td>
                            <td>
                                <Button color="success" onClick={(id) => this.handleEdit(emp.employeeId)}>Edit</Button> |
                                <Button color="danger" onClick={(id) => this.handleDelete(emp.employeeId)}>Delete</Button>
                                {/*<a className="action" onClick={(id) => this.handleEdit(emp.employeeId)}>Edit</a>  |
                                <a className="action" onClick={(id) => this.handleDelete(emp.employeeId)}>Delete</a>*/}
                            </td>
                        </tr>
                    )}
                </tbody>
            </Table>
        );
    }
}