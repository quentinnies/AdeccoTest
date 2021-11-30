import React, { Component } from 'react';

export class Pokemons extends Component {
  static displayName = Pokemons.name;

  constructor(props) {
    super(props);
    this.state = { Pokes: [], loading: true };
  }

  componentDidMount() {
    this.populatePokeData();
  }

  static renderPokeTable(Pokes) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>BaseXP</th>
            <th>height</th>
            <th>weight</th>
            <th>order</th>
            <th>Locations</th>
          </tr>
        </thead>
        <tbody>
          {Pokes.map(Poke =>
            <tr key={Poke.id}>
              <td>{Poke.id}</td>
              <td>{Poke.name}</td>
              <td>{Poke.baseXp}</td>
              <td>{Poke.height}</td>
              <td>{Poke.weight}</td>
              <td>{Poke.order}</td>
              <td>{Poke.locationAreaEncounters}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Pokemons.renderPokeTable(this.state.Pokes);

    return (
      <div>
        <h1 id="tabelLabel" >Pokemons table</h1>
        <p>This data is fetched from the API</p>
        {contents}
      </div>
    );
  }

  async populatePokeData() {
    const response = await fetch('https://localhost:5001/api/Poke');
    const data = await response.json();
    this.setState({ Pokes: data, loading: false });
  }
}
