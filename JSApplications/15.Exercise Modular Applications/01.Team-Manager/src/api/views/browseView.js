import { html } from "../../../../node_modules/lit-html/lit-html.js"
import { getAllTeams } from '..data.js'

export async function browseView(ctx) {
    const teams = await getAllTeams();
    ctx.render(createBrowseTemp(teams))
}

function createTeamTemp(team) {
    return html`
                        <article class="layout">
                            <img src="${team.logoUrl}" class="team-logo left-col">
                            <div class="tm-preview">
                                <h2>${team.name}</h2>
                                <p>${team.description}</p>
                                <span class="details">5000 Members</span>
                                <div><a href="/details/${team._id}" class="action">See details</a></div>
                            </div>
                        </article>
    `
}
function createBrowseTemp(teams) {
    return html`
                <section id="browse">
                
                    <article class="pad-med">
                        <h1>Team Browser</h1>
                    </article>
                
                    <article class="layout narrow">
                        <div class="pad-small"><a href="#" class="action cta">Create Team</a></div>
                    </article>
                    ${teams.map(x => createTeamTemp(x))}
                
                </section>
    `
}

