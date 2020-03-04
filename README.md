# Approachrate Calculator

ARC is a CLI-tool for calculating hit object visibility for osu! beatmaps.

## Documentation

ARC takes three arguments and calculates circle visibility, using the following formulas (which can be found on [osu!wiki](https://github.com/ppy/osu-wiki/blob/master/meta/unused/difficulty-settings.md)):

```yaml
                                        X = perfect hit
              p r e e m p t             ↓
 ├───────────────────────┬──────────────┤
 0%      fade_in           100% opacity
```

The circle starts fading in at `X - preempt` with:

- AR < 5: `preempt = 1200ms + 600ms * (5 - AR) / 5`
- AR = 5: `preempt = 1200ms`
- AR > 5: `preempt = 1200ms - 750ms * (AR - 5) / 5`

The amount of time it takes for hitobjects to fade in is also reliant on approachrate:

- AR < 5: `fade_in = 800ms + 400ms * (5 - AR) / 5`
- AR = 5: `fade_in = 800ms`
- AR > 5: `fade_in = 800ms - 500ms * (AR - 5) / 5`

## Parameters

ARC needs all three arguments with the correct input types to calculate visibility.

Arguments | Input types
:-- | ---
`Approach Rate` | `Double`
`Beats per Minute` | `Double`
`Snap Divisor` | `Integer`

## Output

After execution, ARC will output something similar to this:

![Screenshot](https://i.imgur.com/r3S23RL.jpg " ")
