
tsParticles.load("tsparticles", {
    fpsLimit: 60,
    particles: {
        number: {
            value: 100,
            density: {
                enable: true,
                value_area: 700,
            },
        },
        color: {
            value: ["#aa73ff", "#f8d210", "#84d238"],
        },
        shape: {
            type: "circle",
            stroke: {
                width: 0,
                color: "#5fc8f8",
            },
            polygon: {
                nb_sides: 15,
                color: "#3fc4f2",
            },
        },
        opacity: {
            value: 0.5,
            random: false,
            anim: {
                enable: false,
                speed: 1.5,
                opacity_min: 0.15,
                sync: false,
            },
        },
        size: {
            value: 2.5,
            random: true,
            anim: {
                enable: true,
                speed: 2,
                size_min: 0.15,
                sync: false,
            },
        },
        line_linked: {
            enable: true,
            distance: 200,
            color: "#33b1f8",
            opacity: 0.25,
            width: 1,
        },
        move: {
            enable: true,
            speed: -0.6,
            direction: "none",
            random: true,
            straight: false,
            out_mode: "out",
            bounce: false,
            attract: {
                enable: false,
                rotateX: 700,
                rotateY: 1200,
            },
        },
    },
    interactivity: {
        detect_on: "canvas",
        events: {
            onhover: {
                enable: false,
                mode: "repulse",
            },
            onclick: {
                enable: false,
                mode: "push",
            },
            resize: true,
        },
        modes: {
            grab: {
                distance: 400,
                line_linked: {
                    opacity: 1,
                },
            },
            bubble: {
                distance: 300,
                size: 40,
                duration: 2,
                opacity: 8,
                speed: 3,
            },
            repulse: {
                distance: 200,
                duration: 0.4,
            },
            push: {
                particles_nb: 4,
            },
            remove: {
                particles_nb: 2,
            },
        },
    },
    retina_detect: true,
});