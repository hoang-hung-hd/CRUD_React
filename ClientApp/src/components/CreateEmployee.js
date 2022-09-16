import React, { useState, Component } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, Row, FormGroup, Col, Label, Input } from 'reactstrap';


export class CreateEmp extends Component {
    constructor(props) {
        super(props);
        this.state = { cityList: [], loading: true };
        var response = fetch("/api/city", {
            method: "GET"
        })
            .then(response => response.json())
            .then(data => {
                console.log("construc", data);
                this.setState({ cityList: data, loading: false });
            })
            .catch((err) => {
                console.log(err.message);
            });

    }

    static renderCityList(cityList) {
        return (                   
            <FormGroup>                       
                <Label for="employeeCity">Cities</Label>
                <Input id="employeeCity" name="select" type="select">
                    {cityList.map(city =>
                        <option key={city.cityid} value={city.cityid}> {city.cityName} </option>
                    )}
                </Input>                        
            </FormGroup>
        );
    }
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : CreateEmp.renderCityList(this.state.cityList);
        return (
            <div>
                {contents}
            </div>
        )
    }
}

function EmployeeModal(args) {
    const [modal, setModal] = useState(false);

    const toggle = () => setModal(!modal);

    return (
        <div>
            <Button color="danger" onClick={toggle}>
                Add Employee
            </Button>
            <Modal isOpen={modal} toggle={toggle} {...args}>
                <ModalHeader toggle={toggle}>Modal title</ModalHeader>
                <ModalBody>
                    <Form>
                        <Row xs="4">
                            <Col md={6}>
                                <FormGroup>
                                    <Label for="employeeName">Employee Name</Label>
                                    <Input id="employeeName" name="employeeName" />
                                </FormGroup>
                            </Col>
                            <Col md={6}>
                                <FormGroup>
                                    <Label for="employeeDepartment">Employee Department</Label>
                                    <Input id="employeeDepartment" name="employeeDepartment" />
                                </FormGroup>
                            </Col>
                            <Col md={6}>
                                {/*<FormGroup>
                                    <Label for="employeeCity">Cities</Label>
                                    <Input id="employeeCity" name="select" type="select">
                                        <option>1 </option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4 </option>
                                        <option>5</option>
                                    </Input>
                                </FormGroup>*/}
                                <CreateEmp />
                            </Col>
                            <Col md={6}>
                                <FormGroup>
                                    <Label for="employeeGender">Gender : </Label>
                                    <FormGroup check>
                                        <Input name="employeeGender" type="radio" />
                                        <Label check>Male </Label>
                                    </FormGroup>
                                    <FormGroup check>
                                        <Input name="employeeGender" type="radio" />
                                        <Label check>Female</Label>
                                    </FormGroup>
                                    <FormGroup check>
                                        <Input name="employeeGender" type="radio" />
                                        <Label check>Something else</Label>
                                    </FormGroup>
                                </FormGroup>
                            </Col>


                        </Row>
                    </Form>
                </ModalBody>
                <ModalFooter>
                    <Button color="primary" onClick={toggle}>
                        Create Employee
                    </Button>{' '}
                    <Button color="secondary" onClick={toggle}>
                        Cancel
                    </Button>
                </ModalFooter>
            </Modal>
        </div>
    );
}

export default EmployeeModal;
